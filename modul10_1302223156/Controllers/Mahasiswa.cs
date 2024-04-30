using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modul10_1302223156.Controllers;

public class InputMahasiswa
{
    public string nama { get; set; }
    public string NIM { get; set; }
    public List<string> Course { get; set; }
    public int Year { get; set; }
}
namespace modul10_1302223156.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mahasiswa : Controller
    {
        private static InputMahasiswa[] mahasiswa = new InputMahasiswa[]
        {
                new InputMahasiswa{nama = "Dafa Raimi Suandi",NIM ="1302223156",Course =["PBO","KPL","Basdat"] ,Year = 2022},
                new InputMahasiswa{nama = "Haikal Risnandar",NIM ="1302221050",Course =["PBO","KPL","Basdat"] ,Year = 2022 },
                new InputMahasiswa{nama = "Fersya Zufar",NIM ="1302223090",Course =["PBO","KPL","Basdat"] ,Year = 2022 },
                new InputMahasiswa{nama = "Mahesa Athaya Zain",NIM ="1302220105",Course =["PBO","KPL","Basdat"] ,Year = 2022 },
                new InputMahasiswa{nama = "Darryl Frizangelo Rambi",NIM ="1302223154",Course =["PBO","KPL","Basdat"] ,Year = 2022 },
                new InputMahasiswa{nama = "Raphael Permana Barus",NIM ="1302220140",Course =["PBO","KPL","Basdat"] ,Year = 2022 },
        };
        [HttpGet]
        public IEnumerable<InputMahasiswa> GetMahasiswa()
        {
            return mahasiswa;
        }

        [HttpGet("{id}")]
        public InputMahasiswa Get(int id)
        {
            return mahasiswa[id];
        }
        [HttpPost]
        public IActionResult Post([FromBody] InputMahasiswa input)
        {
            InputMahasiswa newMahasiswa = new InputMahasiswa
            {
                nama = input.nama,
                NIM = input.NIM,
                Course = input.Course,
                Year = input.Year,
            };
            InputMahasiswa[] newMahasiswas = new InputMahasiswa[mahasiswa.Length + 1];

            for (int i = 0; i < mahasiswa.Length; i++)
            {
                newMahasiswas[i] = mahasiswa[i];
            }
            newMahasiswas[mahasiswa.Length] = newMahasiswa;
            mahasiswa = newMahasiswas;

            return CreatedAtAction(nameof(GetMahasiswa), newMahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= mahasiswa.Length)
            {
                return NotFound("Indeks mahasiswa tidak valid");
            }

            
            for (int i = id; i < mahasiswa.Length - 1; i++)
            {
                mahasiswa[i] = mahasiswa[i + 1];
            }
            Array.Resize(ref mahasiswa, mahasiswa.Length - 1);

            
            return NoContent();
        }
    }
}
