using System;
namespace Pokemon.Type.domain
{
    public class Type
    {
        private TypeName _name;

        private Type(TypeName name)
        {
            _name = name;
        }

        public static Create(TypeName name) {
            return new Type(name);
        }

        public TypeName Name() {
            return _name;
        }
    }
}
