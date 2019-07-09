using Blazor.Realm;
using BlazorProject.Shared.DTO;

namespace BlazorProject.Client.Redux.Actions
{
    namespace Pokemon
    {
        public class Set : IRealmAction
        {
            public FullPokemon Value { get; set; }
            public Set(FullPokemon value)
            {
                Value = value;
            }
        }
        public class Reset : IRealmAction { }
        public class Dispose : Reset { }

    }
}
