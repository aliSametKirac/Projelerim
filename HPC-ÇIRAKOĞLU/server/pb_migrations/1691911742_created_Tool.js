/// <reference path="../pb_data/types.d.ts" />
migrate(
  (db) => {
    const collection = new Collection({
      id: "s1ve699cq867gpe",
      created: "2023-08-13 07:29:02.415Z",
      updated: "2023-08-13 07:29:02.415Z",
      name: "Tool",
      type: "base",
      system: false,
      schema: [
        {
          system: false,
          id: "2qp9liro",
          name: "Tool_Name",
          type: "text",
          required: false,
          unique: false,
          options: {
            min: null,
            max: null,
            pattern: "",
          },
        },
        {
          system: false,
          id: "hdgttxba",
          name: "Tool_Text",
          type: "text",
          required: false,
          unique: false,
          options: {
            min: null,
            max: null,
            pattern: "",
          },
        },
        {
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
        },
      ],
      indexes: [],
      listRule: null,
      viewRule: null,
      createRule: null,
      updateRule: null,
      deleteRule: null,
      options: {},
    });

    return Dao(db).saveCollection(collection);
  },
  (db) => {
    const dao = new Dao(db);
    const collection = dao.findCollectionByNameOrId("s1ve699cq867gpe");

    return dao.deleteCollection(collection);
  },
);
