using System;
using System.Collections.Generic;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
    internal class InitialLanePublicCodesGenerator
    {
	    private static readonly DateTime Now = new DateTime(2018, 6, 1);
		internal static IEnumerable<LanePublicCode> GetInitialData()
		{
			yield return new LanePublicCode { Id = Guid.Parse("a687ace6-6a27-441e-983f-11c3e85ce228"), CreatedOn = Now, Code = "01", Description = "", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("775be837-5312-47f7-b26a-183a20b849cc"), CreatedOn = Now, Code = "02", Description = "ALLÉE", Abbreviation = "AL" };
			yield return new LanePublicCode { Id = Guid.Parse("6e3765c2-a5f6-473c-97c2-7288340f7cf9"), CreatedOn = Now, Code = "05", Description = "AUTOROUTE", Abbreviation = "AU" };
			yield return new LanePublicCode { Id = Guid.Parse("c121a6de-3ce1-4c52-8699-21673496512c"), CreatedOn = Now, Code = "08", Description = "AVENUE", Abbreviation = "AV" };
			yield return new LanePublicCode { Id = Guid.Parse("02df7115-99ed-4585-b34e-35646b447ec3"), CreatedOn = Now, Code = "11", Description = "BOULEVARD", Abbreviation = "BD" };
			yield return new LanePublicCode { Id = Guid.Parse("211872bb-6892-44aa-85c6-8590ca3306f4"), CreatedOn = Now, Code = "14", Description = "CARRÉ", Abbreviation = "CA" };
			yield return new LanePublicCode { Id = Guid.Parse("2f682729-d11e-4a22-b577-4ba503f97e0c"), CreatedOn = Now, Code = "15", Description = "CARREFOUR", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("72bd548d-a64c-4467-90cb-c7de605e08bf"), CreatedOn = Now, Code = "16", Description = "CHAUSSÉE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("e0b56a99-7e6e-4dae-a873-f2ea76571394"), CreatedOn = Now, Code = "17", Description = "CHEMIN", Abbreviation = "CH" };
			yield return new LanePublicCode { Id = Guid.Parse("33e0126d-4f30-4491-bd9d-af3433a97a60"), CreatedOn = Now, Code = "19", Description = "CIRCLE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("a0e0125f-fea6-4119-a3d8-d944f49e1329"), CreatedOn = Now, Code = "20", Description = "CERCLE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("64d0478e-e61b-4749-92d4-1ecc2601cf82"), CreatedOn = Now, Code = "21", Description = "CIRCUIT", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("97d7b645-b0ee-43bf-b4bc-9c8d7441e2ec"), CreatedOn = Now, Code = "22", Description = "CONCESSION", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("70119917-9313-4a41-9e23-a3090ae7ec1d"), CreatedOn = Now, Code = "23", Description = "COTE", Abbreviation = "CT" };
			yield return new LanePublicCode { Id = Guid.Parse("5c00c7d3-6a51-4d9b-80d2-840cae69ba68"), CreatedOn = Now, Code = "25", Description = "COURS", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("6c7f0c2b-25ac-45a0-b619-e876cceef57a"), CreatedOn = Now, Code = "26", Description = "COURT", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("ea46553d-0c9b-4619-8782-dd7d7587ff76"), CreatedOn = Now, Code = "29", Description = "CRESCENT", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("0197a327-0c6b-40fb-bae3-cbf0876ccd63"), CreatedOn = Now, Code = "32", Description = "CROISSANT", Abbreviation = "CR" };
			yield return new LanePublicCode { Id = Guid.Parse("fd4a80a3-07eb-4c97-9a04-9d384041ff4c"), CreatedOn = Now, Code = "34", Description = "DESCENTE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("f6632d1e-9c1a-460d-b9f5-2b28a16aa2f2"), CreatedOn = Now, Code = "35", Description = "DESSERTE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("b8632077-1760-4a11-ad0b-f1f5351bbafe"), CreatedOn = Now, Code = "36", Description = "DOMAINE", Abbreviation = "DO" };
			yield return new LanePublicCode { Id = Guid.Parse("92487acb-c039-40fe-b0f2-9e8b10c74055"), CreatedOn = Now, Code = "38", Description = "DRIVE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("eacbbabc-35a0-4fba-8f75-9a3a700461f4"), CreatedOn = Now, Code = "39", Description = "ÉCHANGEUR", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("5c46efb6-eace-47e1-b3cb-94b6cadc40f3"), CreatedOn = Now, Code = "3a", Description = "ALLEY", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("659fc7f6-a843-4259-9693-b3d543791c3e"), CreatedOn = Now, Code = "40", Description = "ESPLANADE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("9ff1ce81-b2fe-4890-8ec4-4a0c03748882"), CreatedOn = Now, Code = "41", Description = "FIEF", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("efa9bcc1-1790-415f-a04b-ab54e9d5f266"), CreatedOn = Now, Code = "44", Description = "GARDEN", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("aef889a9-c2c1-402b-abfe-f5d6deac3e55"), CreatedOn = Now, Code = "45", Description = "GARDENS", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("e19772e4-d798-4dce-aed1-d4658d6b001b"), CreatedOn = Now, Code = "46", Description = "HILL", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("78ea1f8b-8087-460c-bc51-5807d1b81f0f"), CreatedOn = Now, Code = "47", Description = "ILE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("fee1058f-84e6-4277-b11e-6ab1dfcdc774"), CreatedOn = Now, Code = "4a", Description = "ANSE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("9de3c5be-9151-4663-a43e-99ef16a7b044"), CreatedOn = Now, Code = "50", Description = "IMPASSE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("673b55cd-47df-40ad-b6da-4cde98e8fe3e"), CreatedOn = Now, Code = "52", Description = "JARDIN", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("bb955596-9fdb-46b4-be6c-a95d29891a29"), CreatedOn = Now, Code = "53", Description = "LANE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("61c6bed8-ed26-4041-8a3a-e7aff4d1498f"), CreatedOn = Now, Code = "54", Description = "LAC", Abbreviation = "LA" };
			yield return new LanePublicCode { Id = Guid.Parse("aa66b652-9333-4776-9024-36385cfaeb9c"), CreatedOn = Now, Code = "55", Description = "LIGNE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("a8a2d1bb-32f4-4486-b8a9-d81a7a4b440a"), CreatedOn = Now, Code = "56", Description = "MONTÉE", Abbreviation = "MT" };
			yield return new LanePublicCode { Id = Guid.Parse("116521e7-6fd3-4c81-af06-2b7a012f809a"), CreatedOn = Now, Code = "57", Description = "PARK", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("b8d1ab4e-f374-4e09-b090-54d5a920fb8d"), CreatedOn = Now, Code = "58", Description = "PASSERELLE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("8738ffff-6adc-4683-b2ad-385f2a9f6c21"), CreatedOn = Now, Code = "59", Description = "PARC", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("d9dcb3c3-81b7-46d2-ae2d-1e269a0fbf46"), CreatedOn = Now, Code = "60", Description = "PISTE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("3b6330b2-85f2-4bdc-b195-22a312889585"), CreatedOn = Now, Code = "61", Description = "PASSAGE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("86211fe5-c32d-41a9-b2ca-7bb2b71c4822"), CreatedOn = Now, Code = "62", Description = "PLACE", Abbreviation = "PL" };
			yield return new LanePublicCode { Id = Guid.Parse("f237c131-bc90-49c7-9397-6e0c1944ed96"), CreatedOn = Now, Code = "63", Description = "PLAGE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("ed0d9f99-6e1b-473d-965a-84ec85cbba1c"), CreatedOn = Now, Code = "64", Description = "PLAZA", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("33b95a78-143d-44dc-93ff-3fc7bc3e1ad4"), CreatedOn = Now, Code = "65", Description = "PONT", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("0ed50d20-2ec8-4e9d-819a-d0f05ff293e7"), CreatedOn = Now, Code = "66", Description = "PLATEAU", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("ae9182dd-5ff2-48c3-8a2a-1ea01d177926"), CreatedOn = Now, Code = "67", Description = "PORTAGE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("5c2a4daa-1312-4b83-a5f5-a5287296330b"), CreatedOn = Now, Code = "68", Description = "RAMPE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("f3bc54f2-acc4-419f-954b-715486cd1dad"), CreatedOn = Now, Code = "69", Description = "PROMENADE", Abbreviation = "PR" };
			yield return new LanePublicCode { Id = Guid.Parse("7ef21a9e-2818-4e5c-a3a1-94182abb0f6e"), CreatedOn = Now, Code = "70", Description = "QUAI", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("ed7222b0-aaa4-4190-ba68-f6ad1ae9a93d"), CreatedOn = Now, Code = "71", Description = "RANG", Abbreviation = "RG" };
			yield return new LanePublicCode { Id = Guid.Parse("183ce7e6-200d-4343-9a87-e0e9f67c56ba"), CreatedOn = Now, Code = "72", Description = "RIDGE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("e183e9dd-d25c-4b86-880f-6d0785631476"), CreatedOn = Now, Code = "73", Description = "PETIT RANG", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("4cd1da4a-e4bb-497e-93da-3c4a632c7230"), CreatedOn = Now, Code = "74", Description = "ROAD", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("9f480514-00d4-4b14-82c8-81e77795b515"), CreatedOn = Now, Code = "75", Description = "ROND-POINT", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("0f28243f-4fd0-4857-a3e0-61bcf4e195d7"), CreatedOn = Now, Code = "76", Description = "GRAND RANG", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("f253087e-dc1a-4098-a2d4-6ba7312329df"), CreatedOn = Now, Code = "77", Description = "ROUTE", Abbreviation = "RT" };
			yield return new LanePublicCode { Id = Guid.Parse("1442ef04-ac2d-4330-a8e8-d6bced4f5b04"), CreatedOn = Now, Code = "78", Description = "ROUTE RURALE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("63e441f4-27bc-46bf-8288-01b8d92cd8c4"), CreatedOn = Now, Code = "79", Description = "RIVIÈRE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("861203af-8d7a-4263-866b-8093c5365f20"), CreatedOn = Now, Code = "80", Description = "RUE", Abbreviation = "RU" };
			yield return new LanePublicCode { Id = Guid.Parse("d3b5160c-da84-44f2-8003-63121ab8b3fc"), CreatedOn = Now, Code = "83", Description = "RUELLE", Abbreviation = "RL" };
			yield return new LanePublicCode { Id = Guid.Parse("6ffc76ff-1ee5-4ce0-8ffb-016ba900c10a"), CreatedOn = Now, Code = "85", Description = "SENTIER", Abbreviation = "SN" };
			yield return new LanePublicCode { Id = Guid.Parse("f24472cc-9a41-46a3-b2ce-e3d8b078530c"), CreatedOn = Now, Code = "86", Description = "SQUARE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("dd2720b7-5911-4f58-a2ae-c9649063fc45"), CreatedOn = Now, Code = "89", Description = "TERRASSE", Abbreviation = "TE" };
			yield return new LanePublicCode { Id = Guid.Parse("76947afd-aabe-413c-b4c2-ab71864ec348"), CreatedOn = Now, Code = "91", Description = "TRAVERSE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("710dafbd-af2b-4a81-b838-b38fc4058485"), CreatedOn = Now, Code = "92", Description = "TRAIT-CARRÉ", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("bdcc94d9-7a15-4af0-8d0f-7beb7a329259"), CreatedOn = Now, Code = "93", Description = "TUNNEL", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("b94dfb3c-bcaa-432e-911d-3dad09d0f917"), CreatedOn = Now, Code = "94", Description = "VIADUC", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("5b4aa5f4-d2a5-4be2-a8d2-3cb8d403f393"), CreatedOn = Now, Code = "95", Description = "VOIE", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("4e4af5e0-4ed0-409b-8c86-da234ec01c07"), CreatedOn = Now, Code = "96", Description = "RUISSEAU", Abbreviation = "" };
			yield return new LanePublicCode { Id = Guid.Parse("4a20f1ee-b37d-4018-8ecd-3f3120fd26da"), CreatedOn = Now, Code = "97", Description = "ÎLOT", Abbreviation = ""};
		}
    }
}
