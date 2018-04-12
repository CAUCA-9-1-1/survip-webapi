﻿using System;
using System.Collections.Generic;
using System.Text;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.InitialData
{
    internal class InitialLanePublicCodesGenerator
    {
		internal static IEnumerable<LanePublicCode> GetInitialData()
		{
			yield return new LanePublicCode { Code = "01", Description = "", Abbreviation = "" };
			yield return new LanePublicCode { Code = "02", Description = "ALLÉE", Abbreviation = "AL" };
			yield return new LanePublicCode { Code = "05", Description = "AUTOROUTE", Abbreviation = "AU" };
			yield return new LanePublicCode { Code = "08", Description = "AVENUE", Abbreviation = "AV" };
			yield return new LanePublicCode { Code = "11", Description = "BOULEVARD", Abbreviation = "BD" };
			yield return new LanePublicCode { Code = "14", Description = "CARRÉ", Abbreviation = "CA" };
			yield return new LanePublicCode { Code = "15", Description = "CARREFOUR", Abbreviation = "" };
			yield return new LanePublicCode { Code = "16", Description = "CHAUSSÉE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "17", Description = "CHEMIN", Abbreviation = "CH" };
			yield return new LanePublicCode { Code = "19", Description = "CIRCLE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "20", Description = "CERCLE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "21", Description = "CIRCUIT", Abbreviation = "" };
			yield return new LanePublicCode { Code = "22", Description = "CONCESSION", Abbreviation = "" };
			yield return new LanePublicCode { Code = "23", Description = "COTE", Abbreviation = "CT" };
			yield return new LanePublicCode { Code = "25", Description = "COURS", Abbreviation = "" };
			yield return new LanePublicCode { Code = "26", Description = "COURT", Abbreviation = "" };
			yield return new LanePublicCode { Code = "29", Description = "CRESCENT", Abbreviation = "" };
			yield return new LanePublicCode { Code = "32", Description = "CROISSANT", Abbreviation = "CR" };
			yield return new LanePublicCode { Code = "34", Description = "DESCENTE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "35", Description = "DESSERTE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "36", Description = "DOMAINE", Abbreviation = "DO" };
			yield return new LanePublicCode { Code = "38", Description = "DRIVE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "39", Description = "ÉCHANGEUR", Abbreviation = "" };
			yield return new LanePublicCode { Code = "3a", Description = "ALLEY", Abbreviation = "" };
			yield return new LanePublicCode { Code = "40", Description = "ESPLANADE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "41", Description = "FIEF", Abbreviation = "" };
			yield return new LanePublicCode { Code = "44", Description = "GARDEN", Abbreviation = "" };
			yield return new LanePublicCode { Code = "45", Description = "GARDENS", Abbreviation = "" };
			yield return new LanePublicCode { Code = "46", Description = "HILL", Abbreviation = "" };
			yield return new LanePublicCode { Code = "47", Description = "ILE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "4a", Description = "ANSE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "50", Description = "IMPASSE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "52", Description = "JARDIN", Abbreviation = "" };
			yield return new LanePublicCode { Code = "53", Description = "LANE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "54", Description = "LAC", Abbreviation = "LA" };
			yield return new LanePublicCode { Code = "55", Description = "LIGNE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "56", Description = "MONTÉE", Abbreviation = "MT" };
			yield return new LanePublicCode { Code = "57", Description = "PARK", Abbreviation = "" };
			yield return new LanePublicCode { Code = "58", Description = "PASSERELLE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "59", Description = "PARC", Abbreviation = "" };
			yield return new LanePublicCode { Code = "60", Description = "PISTE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "61", Description = "PASSAGE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "62", Description = "PLACE", Abbreviation = "PL" };
			yield return new LanePublicCode { Code = "63", Description = "PLAGE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "64", Description = "PLAZA", Abbreviation = "" };
			yield return new LanePublicCode { Code = "65", Description = "PONT", Abbreviation = "" };
			yield return new LanePublicCode { Code = "66", Description = "PLATEAU", Abbreviation = "" };
			yield return new LanePublicCode { Code = "67", Description = "PORTAGE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "68", Description = "RAMPE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "69", Description = "PROMENADE", Abbreviation = "PR" };
			yield return new LanePublicCode { Code = "70", Description = "QUAI", Abbreviation = "" };
			yield return new LanePublicCode { Code = "71", Description = "RANG", Abbreviation = "RG" };
			yield return new LanePublicCode { Code = "72", Description = "RIDGE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "73", Description = "PETIT RANG", Abbreviation = "" };
			yield return new LanePublicCode { Code = "74", Description = "ROAD", Abbreviation = "" };
			yield return new LanePublicCode { Code = "75", Description = "ROND-POINT", Abbreviation = "" };
			yield return new LanePublicCode { Code = "76", Description = "GRAND RANG", Abbreviation = "" };
			yield return new LanePublicCode { Code = "77", Description = "ROUTE", Abbreviation = "RT" };
			yield return new LanePublicCode { Code = "78", Description = "ROUTE RURALE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "79", Description = "RIVIÈRE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "80", Description = "RUE", Abbreviation = "RU" };
			yield return new LanePublicCode { Code = "83", Description = "RUELLE", Abbreviation = "RL" };
			yield return new LanePublicCode { Code = "85", Description = "SENTIER", Abbreviation = "SN" };
			yield return new LanePublicCode { Code = "86", Description = "SQUARE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "89", Description = "TERRASSE", Abbreviation = "TE" };
			yield return new LanePublicCode { Code = "91", Description = "TRAVERSE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "92", Description = "TRAIT-CARRÉ", Abbreviation = "" };
			yield return new LanePublicCode { Code = "93", Description = "TUNNEL", Abbreviation = "" };
			yield return new LanePublicCode { Code = "94", Description = "VIADUC", Abbreviation = "" };
			yield return new LanePublicCode { Code = "95", Description = "VOIE", Abbreviation = "" };
			yield return new LanePublicCode { Code = "96", Description = "RUISSEAU", Abbreviation = "" };
			yield return new LanePublicCode {Code = "97", Description = "ÎLOT", Abbreviation = ""};
		}
    }
}