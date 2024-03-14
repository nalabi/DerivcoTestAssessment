using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

public class Ingredient
    {


        [Required]
        [JsonProperty("idIngredient")]
        public string idIngredient { get; set; }

        [JsonProperty("strIngredient")]
        public string strIngredient { get; set; }

        [JsonProperty("strDescription")]

        public string strDescription { get; set; }

        [JsonProperty("strType")]
        public string strType { get; set; }

        [Required]
        [JsonProperty("strAlcohol")]
        public string strAlcohol { get; set; }

        [Required]
        [JsonProperty("strABV")]
        public string strABV { get; set; }

    }

     public class IngredientResponse
    {
        public List<Ingredient> ingredients { get; set; }
    }

