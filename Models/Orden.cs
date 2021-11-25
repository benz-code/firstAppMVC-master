using System;
using System.ComponentModel.DataAnnotations;


namespace firstApp.Models
{
   public class Orden
   {
       //Definir propiedades
        [Key]

       public int ordenID {get; set;}
       [Required(ErrorMessage ="Descripcion is required!")]
       [Display(Name= "Descripcion")]

       public string descripcion {get; set;}

       //Referencias para Orden

       [Required(ErrorMessage ="No. Orden is required!")]
       [Display (Name= "No. Orden")]

       public int empresaID {get; set;}

       public Orden Ordens {get; set;} 


   }


}