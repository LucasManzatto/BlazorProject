using Blazor.Realm;
using BlazorProject.Shared.DTO;
using System;

namespace BlazorProject.Client.Redux
{
    public static class Reducers
    {
        public static State RootReducer(State state,IRealmAction action)
        {
            if(state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            return new State
            {
                Pokemon = PokemonReducer(state.Pokemon, action)
            };
        }

        private static FullPokemon PokemonReducer(FullPokemon pokemon, IRealmAction action)
        {
            switch (action)
            {
                case Actions.Pokemon.Set a:
                    return a.Value;
                default:
                    return pokemon;
            }
        }
    }
}
