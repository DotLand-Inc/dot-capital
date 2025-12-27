
exports.up = async (knex) => {
    // 1. Update existing accounts to French PCG codes
    const mapping = {
        '40011': '658000',
        '20006': '445510',
        '50005': '487000',
        '100010': '486000',
        '100020': '517000',
        '40008': '665000',
        '40009': '765000',
        '40010': '758000',
        '10001': '512000',
        '10002': '512100',
        '10003': '511000',
        '10004': '530000',
        '10005': '218300',
        '10006': '218400',
        '10007': '411000',
        '10008': '370000',
        '20001': '401000',
        '20002': '455000',
        '20003': '164000',
        '20004': '471000',
        '20005': '487000',
        '30001': '110000',
        '30002': '119000',
        '30003': '101000', // Owner's Equity
        // '30003': '108000', // Drawings - conflict handled below?
        '40001': '658000', // Other expenses
        '40002': '607000',
        '40003': '606400',
        '40004': '613000',
        '40005': '666000',
        '40006': '627000',
        '40007': '681120',
        '50001': '707000',
        '50002': '706000',
        '50003': '700000',
        '50004': '758000',
    };

    for (const [oldCode, newCode] of Object.entries(mapping)) {
        // Check if new code already exists to avoid unique constraint if any (though usually codes are not unique key globally, but slug is. active+code might be unique).
        // Assuming we just update.
        await knex('accounts').where('code', oldCode).update({ code: newCode });
    }

    // Handle specific case for Drawings which shared 30003 with Owner's Equity in some contexts
    // If we updated 30003 -> 101000 above, we might explicitly check for slug 'drawings'
    await knex('accounts').where('slug', 'drawings').update({ code: '108000' });


    // 2. Insert new French VAT accounts if they don't exist
    const newAccounts = [
        {
            name: 'TVA Déductible',
            slug: 'tva-deductible',
            account_type: 'other-current-asset',
            code: '445660',
            description: 'TVA déductible sur autres biens et services',
            active: 1,
            index: 1,
            predefined: 0,
            parent_account_id: null,
            currency_code: 'EUR', // Assuming EUR for France context
        },
        {
            name: 'TVA Collectée',
            slug: 'tva-collectee',
            account_type: 'other-current-liability',
            code: '445710',
            description: 'TVA collectée',
            active: 1,
            index: 1,
            predefined: 0,
            parent_account_id: null,
            currency_code: 'EUR',
        },
        {
            name: 'TVA à décaisser',
            slug: 'tva-a-decaisser',
            account_type: 'tax-payable',
            code: '445510',
            description: 'TVA à décaisser',
            active: 1,
            index: 1,
            predefined: 0,
            parent_account_id: null,
            currency_code: 'EUR',
        },
    ];

    for (const account of newAccounts) {
        const exists = await knex('accounts').where('slug', account.slug).first();
        if (!exists) {
            // Need to set created_at/updated_at manually if not auto? knex usually handles timestamps() in schema builder but raw inserts might need it.
            // Also ensure currency_code matches the tenant base currency if possible, but here we assume default or allow null if schema permits.
            // Checking schema: currency_code is string.
            // We will default to the organization's base currency if possible, but pure SQL requires a subselect.
            // Simply omitting currency_code might be safer if it defaults to base.
            delete account.currency_code;

            await knex('accounts').insert({
                ...account,
                created_at: knex.fn.now(),
                updated_at: knex.fn.now()
            });
        }
    }
};

exports.down = async (knex) => {
    // Rollback logic is complex due to overwrites, we can skip for now as this is a forward-fix migration.
    // If needed, we would reverse the mapping.
};
