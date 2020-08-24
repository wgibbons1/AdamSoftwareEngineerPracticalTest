using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomerContact
{
    public class AppContractResolver : DefaultContractResolver
    {
        public IDictionary<Type, IEnumerable<string>> TypePropertyNames { get; set; }

        public AppContractResolver() : base() {
            NamingStrategy = new CamelCaseNamingStrategy();
            TypePropertyNames = new Dictionary<Type, IEnumerable<string>>();
        }

        public AppContractResolver(IDictionary<Type, IEnumerable<string>> kvps) : this() {
            TypePropertyNames = kvps;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);
            IEnumerable<string> propertyNames = TypePropertyNames[member.DeclaringType];
            jsonProperty.ShouldSerialize = instance =>
                propertyNames.Any(pn => pn == member.Name);
            return jsonProperty;
        }
    }
}
