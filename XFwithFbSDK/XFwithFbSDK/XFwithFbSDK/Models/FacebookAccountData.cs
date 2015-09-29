using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XFwithFbSDK.Models
{
    public class FacebookAccountData
    {
        public int? CustomerPhoneId { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string SocialNetworkId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "middle_name")]
        public string MiddleName { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "age_range")]
        public string AgeRange { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }
        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }
        [JsonProperty(PropertyName = "updated_time")]
        public string UpdatedTime { get; set; }
        [JsonProperty(PropertyName = "verified")]
        public string Verified { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
