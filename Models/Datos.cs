using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace firstApp.Models
{
   public class Datos
   {
       //Definir propiedades
        [Key]
        
        public int empresaID {get; set;}

        [Required(ErrorMessage ="Empresa is required!")]
      [Display(Name ="Empresa")]

        public string nombreEmpresa {get; set;}
        [Required(ErrorMessage ="Direccion is required!")]
        [Display(Name= "Direccion")]

        public string Direccion {get; set;}

        public ICollection<Orden> Ordens {get; set;} =new List<Orden>();
    




   }


}