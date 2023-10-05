# ArtisanAura Breakfast Api

- [ArtisanAura Breakfast Api](#artisanaura-breakfast-api)
  - [Create Breakfast](#create-breakfast)
    - [Create Breakfast Request](#create-breakfast-request)
    - [Create Breakfast Response](#create-breakfast-response)
  - [Get Breakfast](#get-breakfast)
    - [Get Breakfast Request](#get-breakfast-request)
    - [Get Breakfast Response](#get-breakfast-response)
  - [Update Breakfast](#update-breakfast)
    - [Update Breakfast Request](#update-breakfast-request)
    - [Update Breakfast Response](#update-breakfast-response)
  - [Delete Breakfast](#delete-breakfast)
    - [Delete Breakfast Request](#delete-breakfast-request)
    - [Delete Breakfast Response](#delete-breakfast-response)

## Create Breakfast

```js
POST {{host}}/api/breakfast;
```

### Create Breakfast Request

```json
{
  "name": "Aloo Paratha",
  "description": "Whole wheat bread stuffed with spiced mashed potatoes.",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "savory": [
    "Whole wheat flour",
    "Potatoes",
    "Onions",
    "Green chilies",
    "Spices"
  ],
  "sweet": ["Ghee", "Sugar"]
}
```

### Create Breakfast Response

```json
201 Created
```

```json
{
  "id": "ae890f1f-bfd9-483e-933f-a5d151ce2458",
  "name": "Aloo Paratha",
  "description": "Whole wheat bread stuffed with spiced mashed potatoes.",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "lastModifiedDateTime": "2023-10-05T17:48:54.873537Z",
  "savory": [
    "Whole wheat flour",
    "Potatoes",
    "Onions",
    "Green chilies",
    "Spices"
  ],
  "sweet": ["Ghee", "Sugar"]
}
```

## Get Breakfast

```js
GET {{host}}/api/breakfast/{{id}};
```

### Get Breakfast Request

```json
{}
```

### Get Breakfast Response

```json
200 OK
```

```json
{
  "id": "ae890f1f-bfd9-483e-933f-a5d151ce2458",
  "name": "Aloo Paratha",
  "description": "Whole wheat bread stuffed with spiced mashed potatoes.",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "lastModifiedDateTime": "2023-10-05T17:48:54.873537Z",
  "savory": [
    "Whole wheat flour",
    "Potatoes",
    "Onions",
    "Green chilies",
    "Spices"
  ],
  "sweet": ["Ghee", "Sugar"]
}
```

## Update Breakfast

```js
PUT {{host}}/api/breakfast/{{id}};
```

### Update Breakfast Request

```json
{
  "name": "Aloo Paratha Edited",
  "description": "Whole wheat bread stuffed with spiced mashed potatoes.",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "savory": [
    "Whole wheat flour",
    "Potatoes",
    "Onions",
    "Green chilies",
    "Spices"
  ],
  "sweet": ["Ghee", "Sugar"]
}
```

### Update Breakfast Response

```json
204 No Content
```

## Delete Breakfast

```js
DELETE {{host}}/api/breakfast/{{id}};
```

### Delete Breakfast Request

```json
{}
```

### Delete Breakfast Response

```json
204 No Content
```
