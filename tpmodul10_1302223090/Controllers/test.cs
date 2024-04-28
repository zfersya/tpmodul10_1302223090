using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace tpmodul10_1302223090.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        public class Mahasiswa
        {
            public string Nama { get; set; }
            public string Nim { get; set; }
        }

        private static List<Mahasiswa> mahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa{ Nama = "Fersya Zufar Muhara", Nim = "1302223090"},
            new Mahasiswa{ Nama = "Raphael Permana Barus", Nim = "1302220140"},
            new Mahasiswa{ Nama = "Darryl Frizzangelo", Nim = "1302223154"},
            new Mahasiswa{ Nama = "Dafa Raimi Suandi", Nim = "1302223156"},
            new Mahasiswa{ Nama = "Haikal Risnandar", Nim = "1302221050"},
            new Mahasiswa{ Nama = "Mahesa Athaya Zain", Nim = "1302220105"}
        };

        [HttpGet]
        public IActionResult GetMahasiswa()
        {
            return new OkObjectResult(mahasiswa);
        }

        [HttpGet("{index}")]
        public IActionResult GetMahasiswaByIndex(int index)
        {
            if (index >= 0 && index < mahasiswa.Count)
            {
                return Ok(mahasiswa[index]);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa input)
        {
            mahasiswa.Add(input);
            return CreatedAtAction(nameof(GetMahasiswa), input);
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteMahasiswaByIndex(int index)
        {
            if (index >= 0 && index < mahasiswa.Count)
            {
                mahasiswa.RemoveAt(index);
                return NoContent();
            }
            return NotFound();
        }
    }
}
