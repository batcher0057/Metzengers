using MetzNenger.Core.Data.Models.Abstract;
using System;
using System.Collections.Generic;

namespace MetzNenger.Core.Data.Models
{
    public partial class Fichier : FichierBase
    {
        public Fichier()
        {
            IdMessages = new HashSet<Message>();
        }
    }
}
