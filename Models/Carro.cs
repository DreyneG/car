using System.Net.Http.Headers;
using System;
using System.ComponentModel.DataAnnotations;

namespace api6969.Models
{
    public class Carro
    {
        [Key]
        public string? chassi{get;set;}
        public string? marca{get;set;}
        public string? modelo{get;set;}
        public int ano{get;set;}
        public string? combustivel{get;set;}
        public string? cor{get;set;}
        public string? motor{get;set;}
        public string? cambio{get;set;}


    } 
}
