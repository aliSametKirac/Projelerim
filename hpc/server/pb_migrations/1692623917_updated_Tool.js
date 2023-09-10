/// <reference path="../pb_data/types.d.ts" />
migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("s1ve699cq867gpe")

  collection.indexes = [
    "CREATE INDEX `idx_PtxzVfY` ON `Tool` (\n  `Tool_Image`,\n  `Tool_Name`,\n  `Tool_Text`,\n  `Tool_URl`,\n  `created`,\n  `updated`\n)"
  ]

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("s1ve699cq867gpe")

  collection.indexes = [
    "CREATE INDEX `idx_PtxzVfY` ON `Tool` (\n  `Tool_Image`,\n  `Tool_Name`,\n  `Tool_Text`,\n  `Tool_URl`\n)"
  ]

  return dao.saveCollection(collection)
})
