# Car Journal API

- [Car Journal API](#car-journal-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register request](#register-request)
    - [Login](#login)
      - [Login request](#login-request)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register request

```json
{
    "email": "user@expample.com",
    "password": "hardPassword123"
}
```

### Login

```js
POST {{host}}/auth/login;
```

#### Login request

```json
{
    "email": "user@expample.com",
    "password": "hardPassword123"
}
```
