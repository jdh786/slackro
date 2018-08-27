using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackroCore
{
    public interface IProfanityRepository
    {
        Task<bool> HasProfanity(string text);
        Task<string> FilterProfanity(string text);
    }
}
