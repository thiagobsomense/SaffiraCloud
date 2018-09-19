using System;
using System.ComponentModel.DataAnnotations;

namespace SaffiraCloud.ApplicationCore.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long? ID { get; set; }

        [Display(Name ="Cadastro")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime? DtCadastro { get; set; }

        [Display(Name = "Atualizado")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime? DtAtualizado { get; set; }
    }
}
