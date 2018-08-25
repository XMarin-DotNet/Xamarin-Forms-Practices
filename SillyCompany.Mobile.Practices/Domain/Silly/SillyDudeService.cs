﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SillyFrontService.cs" company="The Silly Company">
//   The Silly Company 2016. All rights reserved.
// </copyright>
// <summary>
//   The SillyFrontService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SillyCompany.Mobile.Practices.Domain;
using SillyCompany.Mobile.Practices.Domain.Silly;
using SillyCompany.Mobile.Practices.Infrastructure;

namespace SillyCompany.Mobile.Practices.Domain.Silly
{
    public class SillyDudeService : ISillyDudeService
    {
        private readonly ErrorEmulator _errorEmulator;
        private readonly int _peopleCounter = 0;
        private readonly Dictionary<int, SillyDude> _repository;

        private readonly Random _randomizer = new Random();

        public SillyDudeService(ErrorEmulator errorEmulator)
        {
            _errorEmulator = errorEmulator;
            _repository = new Dictionary<int, SillyDude>
                {
                    {
                        ++_peopleCounter,
                        new SillyDude(
                            _peopleCounter,
                            "Will Ferrel",
                            "Actor",
                            "Hey.\nThey laughed at Louis Armstrong when he said he was gonna go to the moon.\nNow he’s up there, laughing at them.",
#if LOCAL_DATA
                            "will_ferrell.jpg",
#else
                            "http://www.2oceansvibe.com/wp-content/uploads/2017/10/willlferell.jpg",
#endif
                            4)
                    },
                    {
                        ++_peopleCounter,
                        new SillyDude(
                            _peopleCounter,
                            "Knights of Ni",
                            "Knights",
                            "Keepers of the sacred words 'Ni', 'Peng', and 'Neee-Wom'",
#if LOCAL_DATA
                            "knights_of_ni.jpg",
#else
                            "http://images.uncyc.org/commons/d/dd/The_leader_of_the_Knights_Who_Say_Ni.jpg",
#endif
                            5)
                    },
                    {
                        ++_peopleCounter,
                        new SillyDude(
                            _peopleCounter,
                            "Jean-Claude",
                            "Actor",
                            "J’adore les cacahuètes.\nTu bois une bière et tu en as marre du goût. Alors tu manges des cacahuètes.\nLes cacahuètes, c’est doux et salé, fort et tendre, comme une femme. Manger des cacahuètes. It’s a really strong feeling.\nEt après tu as de nouveau envie de boire une bière.\nLes cacahuètes, c’est le mouvement perpétuel à la portée de l’homme.",
#if LOCAL_DATA
                            "jean_claude_van_damme.jpg",
#else
                            "http://media.popculture.com/2017/06/jean-claude-van-damme-predator-20003834-640x480.jpg",
#endif
                            5)
                    },
                    {
                        ++_peopleCounter,
                        new SillyDude(
                            _peopleCounter,
                            "Louis C.K.",
                            "Comedian",
                            "There are people that really live by doing the right thing, but I don't know what that is, I'm really curious about that.\nI'm really curious about what people think they're doing when they're doing something evil, casually.\nI think it's really interesting, that we benefit from suffering so much, and we excuse ourselves from it.",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                            "http://pixel.nymag.com/imgs/daily/vulture/2016/04/21/21-louis-ck.w529.h529.jpg",
#endif
                            2)
                    },
                    {
                        ++_peopleCounter,
                        new SillyDude(
                            _peopleCounter,
                            "Ricky Gervais",
                            "Comedian",
                            "Science seeks the truth. And it does not discriminate. For better or worse it finds things out.\nScience is humble.\nIt knows what it knows and it knows what it doesn’t know. It bases its conclusions and beliefs on hard evidence -­- evidence that is constantly updated and upgraded.\nIt doesn’t get offended when new facts come along. It embraces the body of knowledge.\nIt doesn’t hold on to medieval practices because they are tradition.",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                            "http://wfmj.images.worldnow.com/images/6382251_G.jpg?auto=webp&disable=upscale&width=800",
#endif
                            3)
                    },
                    {
                        ++_peopleCounter,
                        new SillyDude(
                            _peopleCounter,
                            "Steve Carell",
                            "Comedian",
                            "Everyone said to Vincent van Gogh, \"You can\'t be a great painter, you only have one ear.\"\nAnd you know what he said?\n\"I can\'t hear you.",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                            "http://www4.pictures.zimbio.com/mp/8q1mIIQGkXHm.jpg",
#endif
                            3)
                    },
                    {
                        ++_peopleCounter,
                        new SillyDude(
                            _peopleCounter,
                            "Father Ted",
                            "Priest",
                            "My Lovely Horse,\r\nRunning through the field,\r\nWhere are you going,\r\nWith your fetlocks blowing,\r\nIn the wind.\r\n\r\n“I want to shower you with sugar lumps,\r\nAnd ride you over fences,\r\nI want to polish your hooves every single day,\r\nAnd bring you to the horse dentist.\r\n\r\n“My lovely horse,\r\nYou’re a pony no more,\r\nRunning around,\r\nWith a man on your back,\r\nLike a train in the night,\r\nLike a train in the night!”",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                            "http://cdn.playbuzz.com/cdn/b0cd9743-c236-4c0e-b468-00f83724f117/e2b08eac-053b-4b06-8538-405852dc865b.jpg",
#endif
                            4)
                    },
                    {
                        ++_peopleCounter,
                        new SillyDude(
                            _peopleCounter,
                            "Moss",
                            "IT Guy",
                            "Did you see that ludicrous display last night?\nThe thing about Arsenal is, they always try to walk it in!",
#if LOCAL_DATA
                            "louis_ck.jpg",
#else
                            "http://i123.photobucket.com/albums/o320/lucy_edward/moss_pic2.jpg",
#endif
                            3)
                    },
                };
        }

        public async Task<IReadOnlyList<SillyDude>> GetSillyPeople()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            if (ProcessErrorEmulator())
            {
                return new List<SillyDude>();
            }

            return new List<SillyDude>(_repository.Values);
        }

        public async Task<SillyDude> GetSilly(int id)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            ProcessErrorEmulator();

            return _repository[id];
        }

        public async Task<SillyDude> GetRandomSilly()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            int minId = _repository.Keys.Min();
            int maxId = _repository.Keys.Max();

            return _repository[_randomizer.Next(minId, maxId)];
        }

        private bool ProcessErrorEmulator()
        {
            switch (_errorEmulator.ErrorType)
            {
                case ErrorType.Unknown:
                    throw new InvalidOperationException();
                case ErrorType.Network:
                    throw new NetworkException();
                case ErrorType.Server:
                    throw new ServerException();
                case ErrorType.NoData:
                    return true;
                default:
                    return false;
            }
        }
    }
}