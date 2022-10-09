
SELECT * FROM Classe ORDER BY id_promotion;

SELECT * FROM Utilisateur ORDER BY id_utilisateur;

SELECT * FROM Channel ORDER BY id_channel;


SELECT * FROM Message ORDER BY id_message;

SELECT * FROM Fichier ORDER BY id_fichier;

SELECT COUNT(id_signet) FROM Signet;

SELECT * FROM Utilisateur WHERE statut_administratif='Administrateur';

SELECT id_message,horodatage,corps FROM Utilisateur,Message WHERE Utilisateur.pseudo = 'BlueMoon' AND Message.id_utilisateur = Utilisateur.id_utilisateur;


SELECT nom,prenom,pseudo FROM Utilisateur,Classe WHERE Classe.libelle_promotion = 'RAN2' AND Utilisateur.id_promotion = Classe.id_promotion;

SELECT validation_compte FROM Utilisateur WHERE email = 'facilisis.lorem.tristique@protonmail.ca' AND password = 'ASR82QKS6DL';
