﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Model.Models;

public partial class Cliente
{
    [HiddenInput(DisplayValue = false)]
    [DisplayName("Código")]
    public int IdCliente { get; set; }

    [DisplayName("Nome")]
    [Required(ErrorMessage = "O Nome do Cliente é Obrigatório")]
    public string Nome { get; set; }

    [DisplayName("CPF")]
    [Required(ErrorMessage = "O CPF é obrigatório")]
    public string Cpf { get; set; }

    [DisplayName("Cidade")]
    [Required(ErrorMessage = "A Cidade é Obrigatória")]
    public string Cidade { get; set; }

    [DisplayName("E-Mail")]
    [Required(ErrorMessage = "O Email é Obrigatório")]
    public string Email { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}