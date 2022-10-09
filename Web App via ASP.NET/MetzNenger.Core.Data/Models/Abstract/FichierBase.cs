using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models.Abstract
{
    public class FichierBase
    {

        public int IdFichier { get; set; }
        public string? NomFichier { get; set; }
        public string TypeFichier { get; set; } = null!;
        public string HachageFichier { get; set; } = null!;

        public FichierBase(int idFichier, string? nomFichier, string typeFichier, string hachageFichier)
        {
            IdFichier = idFichier;
            NomFichier = nomFichier;
            TypeFichier = typeFichier ?? throw new ArgumentNullException(nameof(typeFichier));
            HachageFichier = hachageFichier ?? throw new ArgumentNullException(nameof(hachageFichier));
        }

        public virtual ICollection<Message> IdMessages { get; set; }
        public FichierBase()
        {
            IdMessages = new HashSet<Message>();
        }
    }
}