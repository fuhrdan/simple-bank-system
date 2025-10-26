//*****************************************************************************
//** 2043. Simple Bank System                                       leetcode **
//*****************************************************************************
//** Accounts in order, each balance in place,                               **
//** Transfers and deposits keep steady pace.                                **
//** Withdraw if you can, but check every rule,                              **
//** For logic and balance must govern the tool.                             **
//*****************************************************************************

typedef struct {
    long long *bal;
    int n;
} Bank;

Bank* bankCreate(long long* balance, int balanceSize) {
    Bank* obj = (Bank*)malloc(sizeof(Bank));
    if (!obj) return NULL;
    obj->n = balanceSize;
    obj->bal = (long long*)malloc(sizeof(long long) * balanceSize);
    if (!obj->bal) {
        free(obj);
        return NULL;
    }
    /* copy initial balances (simple, fast) */
    memcpy(obj->bal, balance, sizeof(long long) * balanceSize);
    return obj;
}

bool bankTransfer(Bank* obj, int account1, int account2, long long money) {
    if (!obj) return false;
    /* validate account indices (1-based in problem statement) */
    if (account1 < 1 || account1 > obj->n) return false;
    if (account2 < 1 || account2 > obj->n) return false;
    int i1 = account1 - 1;
    int i2 = account2 - 1;
    if (obj->bal[i1] < money) return false; /* not enough funds */
    obj->bal[i1] -= money;
    obj->bal[i2] += money;
    return true;
}

bool bankDeposit(Bank* obj, int account, long long money) {
    if (!obj) return false;
    if (account < 1 || account > obj->n) return false;
    obj->bal[account - 1] += money;
    return true;
}

bool bankWithdraw(Bank* obj, int account, long long money) {
    if (!obj) return false;
    if (account < 1 || account > obj->n) return false;
    int idx = account - 1;
    if (obj->bal[idx] < money) return false; /* insufficient funds */
    obj->bal[idx] -= money;
    return true;
}

void bankFree(Bank* obj) {
    if (!obj) return;
    free(obj->bal);
    free(obj);
}


/**
 * Your Bank struct will be instantiated and called as such:
 * Bank* obj = bankCreate(balance, balanceSize);
 * bool param_1 = bankTransfer(obj, account1, account2, money);
 
 * bool param_2 = bankDeposit(obj, account, money);
 
 * bool param_3 = bankWithdraw(obj, account, money);
 
 * bankFree(obj);
*/