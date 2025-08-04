using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Configuration.Constants;



namespace WebApplication2.Configuration.Constants
{
    public static class ErrorConstants
    {
        public const string GET_DATA_FAILED = "Se ha producido un error al obtener los datos. Favor de intentarlo de nuevo más tarde. ";
        public const string ADD_FAILED = "Se ha producido un error al guardar los datos. Favor de intentarlo de nuevo más tarde. ";
        public const string UPDATE_FAILED = "Se ha producido un error al actualizar los datos. Favor de intentarlo de nuevo más tarde. ";
        public const string DELETE_FAILED = "Se ha producido un error al eliminar los datos. Favor de intentarlo de nuevo más tarde. ";
        public const string RECORD_NOTFOUND = "No se encontó registro con los parámetros proporcionados. ";
        public const string CLUB_MATCH_NOTFOUND = "No se encontó club en el partido con los parámetros proporcionados. ";
        public const string MATCH_NOTFOUND = "No se encontó partido con los parámetros proporcionados. ";
        public const string TOURNAMENT_NOTFOUND = "No se encontó torneo con los parámetros proporcionados. ";
        public const string RECORDS_NOTFOUND = "No se encontraron registros con los Ids proporcionados. ";
        public const string INVALID_CREDENTIALS = "Email o contraseña incorrectos. ";
        public const string GENERAL_EXCEPTION_MESSAGE = "Ocurrió un error al procesar la solicitud. Favor de intentarlo mas tarde. ";
        public const string RESOURCE_ALREADY_IN_DATABASE = "Ya existe un registro en la base de datos. ";

        public const string NUMBER_OF_COMPETITORS_NOT_ALLOWED = "El número de participantes no es válido. ";
        public const string NUMBER_OF_PLAYERS_NOT_ALLOWED = "El número de jugadores no es válido. Debe haber por lo menos {0} jugadores";
        public const string PLAY_AGAINST_YOURSELF_NOT_ALLOWED = "No se puede competir contra sí mismo. ";
        public const string ONLY_ONE_LOCAL_TEAM_ALLOWED = "Debe haber al menos un equipo local. ";
        public const string PLAYERS_DO_NOT_BELONG_CLUB = "Los jugadores no pertenecen al club: ";
        public const string NO_AGE_SETTINGS = "El torneo no tiene configuración de edades para la categoría actual. ";
        public const string PLAYERS_OUT_OF_CATEGORY = "Los jugadores no pueden ser alineados a una categoria menor a la que pertenecen: ";
    }
}
