# GeoMarker API

#### Login Response

```json
{
	"id": "d56c9d8z-zf5h-9632-v450y55fd154",
	"firstName": "Pierre",
	"lastName": "Dupont",
	"email":"pierre.dupont@gmail.com",
	"token":"eydpR...QAenciQ"
}
```


## Authentifcation

#### Register

```js
POST {{host}}/api/auth/register
```


##### Register Request

```json
{
	"id": "d56c9d8z-zf5h-9632-v450y55fd154",
	"firstName": "Pierre",
	"lastName": "Dupont",
	"email":"pierre.dupont@gmail.com",
	"password":"circle95@!"
}
```

#### Register Response

```json{
200 OK
```

```json
{
"message": "User created successfully"
}
```