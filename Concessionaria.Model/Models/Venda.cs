﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Model.Models;

public partial class Venda
{
    [HiddenInput(DisplayValue = false)]
    [DisplayName("Codigo")]
    public int IdVenda { get; set; }

    [DisplayName("Cliente")]
    [HiddenInput(DisplayValue = false)]
    public int ClienteIdCliente { get; set; }
    
    [HiddenInput(DisplayValue = false)]
    public int VeiculoIdVeiculo { get; set; }

    [DisplayName("Data Da Venda")]
    [Required(ErrorMessage = "A Data da Venda é Obrigatória")]
    public DateTime? DataVenda { get; set; }

    public virtual Cliente ClienteIdClienteNavigation { get; set; }

    public virtual Veiculo VeiculoIdVeiculoNavigation { get; set; }
}