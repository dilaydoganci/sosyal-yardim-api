using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SosyalYardimApi.Data;
using SosyalYardimApi.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SosyalYardimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SosyalYardimController : ControllerBase
    {
        private readonly SosyalYardimContext _context;

        public SosyalYardimController(SosyalYardimContext context)
        {
            _context = context;
        }

        // GET: api/SosyalYardim/SorgulaSosyalOdeme/{tckn}
        [HttpGet("SorgulaSosyalOdeme/{tckn}")]
        public async Task<ActionResult<IEnumerable<SosyalYardim>>> SorgulaSosyalOdeme(string tckn)
        {
            var odemeler = await _context.SosyalYardimlar.Where(o => o.TcKimlikNo == tckn).ToListAsync();
            return Ok(new { success = true, statusCode = 200, response = odemeler });
        }

        // POST: api/SosyalYardim/OdemeYap
        [HttpPost("OdemeYap")]
        public async Task<ActionResult> OdemeYap([FromBody] OdemeYapRequest request)
        {
            // Veritabanında ödeme kaydını arar
            var odeme = await _context.SosyalYardimlar
                .Where(o => o.Id == request.OdemeNo && o.TcKimlikNo == request.TcKimlikNo)
                .FirstOrDefaultAsync();

            // Eğer ödeme kaydı bulunamazsa
            if (odeme == null)
                return BadRequest(new { success = false, statusCode = 400, message = "Ödeme bulunamadı." });

            // Eğer ödeme daha önce yapılmışsa veya ödeme tarihi geçmemişse
            if (odeme.OdemeKd == 1)
                return BadRequest(new { success = false, statusCode = 400, message = "Bu ödeme daha önce yapılmış." });

            if (odeme.OdemeTr > DateTime.Now)
                return BadRequest(new { success = false, statusCode = 400, message = "Ödeme tarihi henüz gelmedi." });

            // Ödeme durumu günceller
            odeme.OdemeKd = 1;
            await _context.SaveChangesAsync();

            // Başarılı yanıt döndürür
            return Ok(new { success = true, statusCode = 200, message = "Ödeme başarıyla yapıldı." });
        }
    }


    public class OdemeYapRequest
    {
        public string TcKimlikNo { get; set; }
        public int OdemeNo { get; set; }
    }
}

    
