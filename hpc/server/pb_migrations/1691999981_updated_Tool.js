/// <reference path="../pb_data/types.d.ts" />
migrate(
  (db) => {
    const dao = new Dao(db);
    const collection = dao.findCollectionByNameOrId("s1ve699cq867gpe");

    // update
    collection.schema.addField(
      new SchemaField({
        system: false,
        id: "zn8m8nzu",
        name: "Tool_URl",
        type: "url",
        required: false,
        unique: false,
        options: {
          exceptDomains: null,
          onlyDomains: null,
        },
      }),
    );

    return dao.saveCollection(collection);
  },
  (db) => {
    const dao = new Dao(db);
    const collection = dao.findCollectionByNameOrId("s1ve699cq867gpe");

    // update
    collection.schema.addField(
      new SchemaField({
        system: false,
        id: "zn8m8nzu",
        name: "Tool_URL",
        type: "url",
        required: false,
        unique: false,
        options: {
          exceptDomains: null,
          onlyDomains: null,
        },
      }),
    );

    return dao.saveCollection(collection);
  },
);
