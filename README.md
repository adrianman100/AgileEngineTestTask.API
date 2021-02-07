# Money Accounting API Documentation

# Account Resources

The account resources properties and methods that are useful for financial account are the following:

## Get Account Balance

Retrieve the account balance.

**URL** : `/api/MoneyAccounting/balance`

**Method** : `GET`

**Auth required** : NO



# Transaction Resources

Here are the transaction resources properties and methods that are useful for financial transactions.


## Get Transactions

Retrieve the transaction list.

**URL** : `/api/MoneyAccounting/transactions`

**Method** : `GET`

**Auth required** : NO


## Commit Transaction

Commit new transaction to the account

**URL** : `/api/MoneyAccounting/transactions/commit`

**Method** : `POST`

**Auth required** : NO


## Get Transaction

Retrieve transaction by Id.

**URL** : `/api/MoneyAccounting/transactions/{id}`

**Method** : `GET`

**Auth required** : NO
