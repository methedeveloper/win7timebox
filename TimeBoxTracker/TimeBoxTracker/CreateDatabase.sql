CREATE TABLE "project" (
    "id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    "name" TEXT NOT NULL,
    "color" INTEGER
)

CREATE TABLE "task" (
    "id" INTEGER PRIMARY KEY AUTOINCREMENT,
    "name" TEXT NOT NULL,
    "id_project" INTEGER NOT NULL,
    FOREIGN KEY (id_project) REFERENCES project(id) ON DELETE CASCADE
)

CREATE TABLE "timebox" (
    "id" INTEGER PRIMARY KEY AUTOINCREMENT,
    "starttime" INTEGER NOT NULL,
    "endtime" INTEGER NOT NULL,
    "pauses" INTEGER,
    "id_task" INTEGER NOT NULL,
    FOREIGN KEY (id_task) REFERENCES task(id) ON DELETE CASCADE
)