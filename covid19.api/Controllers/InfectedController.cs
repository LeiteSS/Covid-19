using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using covid19.api.Data.Collections;
using covid19.api.Models;

namespace covid19.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;

        IMongoCollection<Infected> _infectedCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SaveInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.BirthDate, dto.Genre, dto.Latitude, dto.Longitude);

            _infectedCollection.InsertOne(infected);

            return StatusCode(201, "Success to save infected");
        }

        [HttpGet]
        public ActionResult GetInfected()
        {
            var infected = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();

            return Ok(infected);
        }

        [HttpPut]
        public ActionResult UpdateInfected([FromBody] InfectedDto dto)
        {
            _infectedCollection.UpdateOne(Builders<Infected>.Filter.Where(_ => _.BirthDate == dto.BirthDate), Builders<Infected>.Update.Set("genre", dto.Genre));

            return Ok("Success to Update");
        }

        [HttpDelete("/{birthDate}")]
        public ActionResult DeleteInfected(DateTime birthDate)
        {
            _infectedCollection.DeleteOne(Builders<Infected>.Filter.Where(_ => _.BirthDate == birthDate));

            return Ok("Success to Delete");
        }

    }
}