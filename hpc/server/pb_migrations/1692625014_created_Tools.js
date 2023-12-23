/// <reference path="../pb_data/types.d.ts" />
migrate((db) => {
  const collection = new Collection({
    "id": "n5cfbyks2gbj5tr",
    "created": "2023-08-21 13:36:54.996Z",
    "updated": "2023-08-21 13:36:54.996Z",
    "name": "Tools",
    "type": "base",
    "system": false,
    "schema": [
      {
        "system": false,
        "id": "ra51ahgz",
        "name": "Tools_Name",
        "type": "text",
        "required": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null,
          "pattern": ""
        }
      },
      {
        "system": false,
        "id": "aifs0wny",
        "name": "Tools_Text",
        "type": "text",
        "required": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null,
          "pattern": ""
        }
      },
      {
        "system": false,
        "id": "esjvlvgf",
        "name": "Tools_URl",
        "type": "url",
        "required": false,
        "unique": false,
        "options": {
          "exceptDomains": null,
          "onlyDomains": null
        }
      },
      {
        "system": false,
        "id": "rxjsxjlo",
        "name": "Tools_Image",
        "type": "file",
        "required": false,
        "unique": false,
        "options": {
          "maxSelect": 1,
          "maxSize": 5242880,
          "mimeTypes": [],
          "thumbs": [],
          "protected": false
        }
      }
    ],
    "indexes": [],
    "listRule": null,
    "viewRule": null,
    "createRule": null,
    "updateRule": null,
    "deleteRule": null,
    "options": {}
  });

  return Dao(db).saveCollection(collection);
}, (db) => {
  const dao = new Dao(db);
  const collection = dao.findCollectionByNameOrId("n5cfbyks2gbj5tr");

  return dao.deleteCollection(collection);
})
