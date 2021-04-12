//Created by Jorik Weymans 2020

namespace Jorik
{
	public static class Cursor
    {
        private static BaseGem _GemOnCursor = null;



        public static bool HasGem() => _GemOnCursor != null;
        public static BaseGem GetGem() => _GemOnCursor;

        public static BaseGem RemoveGem()
        {
            BaseGem returnGem = _GemOnCursor;
            returnGem.State = GemState.CharacterInventory;

            _GemOnCursor = null;
            
            return returnGem;
        }

        public static void SetGem(BaseGem gem)
        {
            _GemOnCursor = gem;
            _GemOnCursor.State = GemState.Cursor;
        }

    }
}

