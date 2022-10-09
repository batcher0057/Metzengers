CREATE DATABASE Metzenger;
GO

USE Metzenger;
GO

CREATE TABLE Signet(
   id_signet INT IDENTITY,
   PRIMARY KEY(id_signet)
);
GO

CREATE TABLE Fichier(
   id_fichier INT IDENTITY,
   nom_fichier VARCHAR(100),
   type_fichier VARCHAR(20) NOT NULL,
   hachage_fichier VARCHAR(128) NOT NULL,
   PRIMARY KEY(id_fichier)
);
GO

CREATE TABLE Classe(
   id_promotion INT IDENTITY,
   libelle_promotion VARCHAR(50) NOT NULL,
   PRIMARY KEY(id_promotion),
   UNIQUE(libelle_promotion)
);
GO

CREATE TABLE Utilisateur(
   id_utilisateur INT IDENTITY,
   email VARCHAR(250) NOT NULL,
   password VARCHAR(250) NOT NULL,
   pseudo VARCHAR(50),
   statut_administratif VARCHAR(50) NOT NULL,
   nom VARCHAR(50) NOT NULL,
   prenom VARCHAR(50) NOT NULL,
   telephone VARCHAR(20),
   validation_compte BIT NOT NULL,
   id_promotion INT,
   PRIMARY KEY(id_utilisateur),
   UNIQUE(email),
   FOREIGN KEY(id_promotion) REFERENCES Classe(id_promotion)
);
GO

CREATE TABLE Channel(
   id_channel INT IDENTITY,
   libelle_channel VARCHAR(50) NOT NULL,
   id_utilisateur INT NOT NULL,
   PRIMARY KEY(id_channel),
   UNIQUE(libelle_channel),
   FOREIGN KEY(id_utilisateur) REFERENCES Utilisateur(id_utilisateur)
);
GO

CREATE TABLE Message(
   id_message INT IDENTITY,
   horodatage DATETIME2 NOT NULL,
   corps VARCHAR(1000),
   enregistrement_favori BIT,
   id_utilisateur INT NOT NULL,
   id_channel INT NOT NULL,
   PRIMARY KEY(id_message),
   FOREIGN KEY(id_utilisateur) REFERENCES Utilisateur(id_utilisateur),
   FOREIGN KEY(id_channel) REFERENCES Channel(id_channel)
);
GO

CREATE TABLE Envoyer_Recevoir(
   id_utilisateur INT,
   id_message INT,
   date_lecture DATE,
   PRIMARY KEY(id_utilisateur, id_message),
   FOREIGN KEY(id_utilisateur) REFERENCES Utilisateur(id_utilisateur),
   FOREIGN KEY(id_message) REFERENCES Message(id_message)
);
GO

CREATE TABLE Archive(
   id_utilisateur INT,
   id_message INT,
   id_signet INT,
   PRIMARY KEY(id_utilisateur, id_message, id_signet),
   FOREIGN KEY(id_utilisateur) REFERENCES Utilisateur(id_utilisateur),
   FOREIGN KEY(id_message) REFERENCES Message(id_message),
   FOREIGN KEY(id_signet) REFERENCES Signet(id_signet)
);
GO

CREATE TABLE Accede(
   id_utilisateur INT,
   id_channel INT,
   PRIMARY KEY(id_utilisateur, id_channel),
   FOREIGN KEY(id_utilisateur) REFERENCES Utilisateur(id_utilisateur),
   FOREIGN KEY(id_channel) REFERENCES Channel(id_channel)
);
GO

CREATE TABLE Inclut(
   id_message INT,
   id_fichier INT,
   PRIMARY KEY(id_message, id_fichier),
   FOREIGN KEY(id_message) REFERENCES Message(id_message),
   FOREIGN KEY(id_fichier) REFERENCES Fichier(id_fichier)
);
GO