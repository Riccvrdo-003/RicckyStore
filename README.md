Manuel de déploiement

Pour pouvoir uiliser l’application sur votre pc, vous devez installer les logiciels suivant :
-Visual Studio Community 2022 : vous devez installez les modules Développement web et ASP.NET, Développement .NET Desktop, Développement d’application Windows et Stockage et traitement des données.
-Microsoft SQL Server Management Studio
Ensuite, ouvrez SQL Server management Studio, cochez la case ‘trust server certificate’, cliquez sur connect, et sur la colonne à gauche, faites un clic droit sur le dossier Databases et cliquez sur ‘Import Data-tier apllication..’. S
uivez les instructions de l’assistant d’importation et choisissez le fichier ‘Storedb.bacpac’. A la fin, vous devez avoir la base de données Storedb dan le dossier Databases. Si vous ne le voyez pas, cliquez sur l’icone Refresh.
Puis, ouvrez Visual Studio, cliquez sur ouvrir un projet ou une solution, puis dans le dossier RicckyStore, choisissez le fichier RickyStrore.sln. Vous devriez maintenant voir le code. 
Maintenant, dans les onglets supérieurs, cliquez sur Affichage puis sur Explorateurs de Serveurs. 
Dans l’explorateurs de serveurs, à gauche de l’icône pour actualiser, cliquez sur l’icône connexion à la base de données. Vous devriez avoir une fenêtre titrée Ajouter une connexion qui s’est affichée. 
Dans Microsoft SQL Server, regardez le nom juste au-dessus du dossier Databases. C’est le nom de votre server. 
Ignorez les caractères entre perenthèses et entrez le reste dans le champ Nom du serveur au niveau de la fenêtre ajouter une connexion. 
Ensuite, cochez la case Certificat du serveur de confiance, choisissez Storedb au niveau du champ Selectionner ou entrer un nom de base de données, et cliquez sur ok.
Vous devriez voir la connexion en vert apparaitre dans l’explorateur de serveurs.
Enfin, exécuter l’application en cliquant sur le triangle vert avec l’écriture https. Une nouvelle fenêtre de votre navigateur par défaut va s’ouvrir et afficher l’application.
