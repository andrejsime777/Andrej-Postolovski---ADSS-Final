using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApplication.Data.Entities;
using UniversityApplication.Data.Interfaces;
using UniversityApplication.Models.DTOs;
using UniversityApplication.Service.Services;
using Xunit;

namespace UniversityApplication.Tests
{
    public class PlayerServiceUnitTests
    {
        IPlayerRepository PlayerRepo;
        IMapper mapper;
        Mock<IPlayerRepository> PlayerRepoMock = new Mock<IPlayerRepository>();
        Player Player;
        PlayerDTO PlayerDTO;
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        List<Player> Players = new List<Player>();
        List<PlayerDTO> PlayerDTOList = new List<PlayerDTO>();

        private void SetupMocks()
        {
            PlayerRepo = PlayerRepoMock.Object;
            mapper = mapperMock.Object;
        }

        private void SetupPlayerDTOMocks()
        {
            Player = GetPlayer();

            mapperMock.Setup(o => o.Map<PlayerDTO>(Player))
                .Returns(GetPlayerDTO());
        }
        private void SetupPlayerDTOListMocks()
        {
            PlayerDTO = GetPlayerDTO();
            var PlayerDTO2 = GetPlayerDTO();
            PlayerDTO2.Id = 2;

            PlayerDTOList.Add(PlayerDTO);
            PlayerDTOList.Add(PlayerDTO2);

            Players = GetPlayers();

            mapperMock.Setup(o => o.Map<List<PlayerDTO>>(Players))
                .Returns(PlayerDTOList);
        }

        private static Player GetPlayer()
        {
            return new Player
            {
                Id = 1,
                FirstName = "Andrej",
                LastName = "Postolovski",
                DOB = DateTime.Today.AddYears(-20),
                SigningDate = DateTime.Today.AddYears(-4),
                Rank = 5,
                TotalGoals = 5,
                ClubId = 2
            };
        }

        private static PlayerDTO GetPlayerDTO()
        {
            return new PlayerDTO
            {
                Id = 5,
                FirstName = "Petko",
                LastName = "Stankovski",
                DOB = DateTime.Today.AddYears(-32),
                SigningDate = DateTime.Today.AddYears(-10),
                Rank = 5,
                TotalGoals = 1522,
                ClubId = 1

            };
        }

        private static List<Player> GetPlayers()
        {
            return new List<Player>()
            {
                new Player()
                {
                     Id = 2,
                     FirstName = "Filip",
                     LastName = "Simonovski",
                     DOB = DateTime.Today.AddYears(-24),
                     SigningDate = DateTime.Today.AddYears(-6),
                     Rank = 5,
                     TotalGoals = 859,
                     ClubId = 4
                },
                 new Player()
                 {
                   Id = 3,
                   FirstName = "Stanko",
                   LastName = "Petkovski",
                   DOB = DateTime.Today.AddYears(-50),
                   SigningDate = DateTime.Today.AddYears(-20),
                   Rank = 5,
                   TotalGoals = 75411,
                   ClubId = 3
                 },
               new Player()
               {
                   Id = 4,
                   FirstName = "Petar",
                   LastName = "Petrovski",
                   DOB = DateTime.Today.AddYears(-12),
                   SigningDate = DateTime.Today.AddYears(-1),
                   Rank = 5,
                   TotalGoals = 8,
                   ClubId = 5
               }
            };
        }

        [Fact]
        public void GetPlayerByIdWhenCalledReturnsPlayer()
        {
            //Arrange
            Player = GetPlayer();
            SetupMocks();
            SetupPlayerDTOMocks();

            PlayerRepoMock
                .Setup(o => o.GetPlayerById(It.IsAny<int>()))
                .Returns(Player);

            var PlayerService = new PlayerService(PlayerRepo, mapper);
            int id = 1;


            //Act 
            PlayerDTO response = PlayerService.GetPlayerById(id);

            //Assert
            Assert.True(response != null);
            Assert.NotNull(response);
            Assert.Equal(5, response.Id);
            Assert.NotEqual(id, response.Id);
        }

        [Fact]
        public void GetPlayersWhenCalledReturnsPlayer()
        {
            //Arrage 
            Players = GetPlayers();
            SetupMocks();
            SetupPlayerDTOListMocks();

            PlayerRepoMock
            .Setup(o => o.GetPlayers())
            .Returns(Players);

            var PlayerService = new PlayerService(PlayerRepo, mapper);

            // Act
            List<PlayerDTO> response = PlayerService.GetPlayers();

            // Assert
            Assert.True(response != null);
        }

        [Fact]
        public void GetPlayersWhenCalledOnThreePlayersReturnsTwoPlayer()
        {
            //Arrange
            Players = GetPlayers();
            SetupMocks();
            SetupPlayerDTOListMocks();

            PlayerRepoMock
                .Setup(o => o.GetPlayers())
                .Returns(Players);

            var PlayerService = new PlayerService(PlayerRepo, mapper);

            //Act
            List<PlayerDTO> response = PlayerService.GetPlayers();

            //Assert
            Assert.NotNull(response);
            Assert.Equal(2, response.Count());
            Assert.NotEqual(1, response.Count());
        }
    }
}
