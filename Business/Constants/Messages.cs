﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Das Auto wurde hinzugefügt";
        public static string CarNameInvalid = "Der Autoname ist ungültig";
        public static string CarsListed = "Die Autos wurden aufgelistet";
        public static string MaintenanceTime = "Das System ist in Wartung";

        public static string ColorAdded = "Die Farbe wurde hinzugefügt";
        public static string ColorDeleted="Die Farbe wurde gelöscht";
        public static string ColorUpdated = "Die Farbe wurde aktualisiert";
        public static string ColorsListed = "Die Farben wurden aufgelistet";

        public static string BrandAdded = "Die Automarke wurde hinzugefügt";
        public static string BrandDeleted = "Die Automarke wurde gelöscht";
        public static string BrandUpdated = "Die Automarke wurde aktualisiert";
        public static string BrandsListed = "Die Automarken wurden aufgelistet";

        public static string UserAdded = "Der Benutzer wurde hinzugefügt";
        public static string UserDeleted = "Der Benutzer wurde gelöscht";
        public static string UserUpdated = "Der Benutzer wurde aktualisiert";
        public static string UsersListed = "Die Benutzer wurden aufgelistet";

        public static string CustomerAdded = "Der Kunde wurde hinzugefügt";
        public static string CustomerDeleted = "Der Kunde wurde gelöscht";
        public static string CustomerUpdated = "Der Kunde wurde aktualisiert";
        public static string CustomerListed = "Die Kunden wurden aufgelistet";

        public static string RentalAdded = "Die Miettransaktion wurde hinzugefügt";
        public static string RentalDeleted = "Die Miettransaktion wurde gelöscht";
        public static string RentalUpdated = "Die Miettransaktion wurde aktualisiert";
        public static string RentalListed = "Die Miettransaktionen wurden aufgelistet";

        public static string ColorCountOfCarError= "In einem Auto kann maximal eine Farbe sein.";
        public static string ColorAlreadyExists="Diese Farbe gibt es schon.";
        public static string ColorLimitExceded= "Wegen der Überschreitung des Farbenlimits können keine neuen Farben hinzugefügt werden.";
        public static string UserRegistered = "Benutzer wurde registriert.";
        public static string UserNotFound = "Benutzer nicht gefunden.";
        public static string PasswordError = "Falsches Passwort.";
        public static string SuccessfulLogin = "Erfolgreiche Anmeldung.";
        public static string UserAlreadyExists = "Benutzer ist bereits vorhanden.";
        public static string AccessTokenCreated = "Anmeldung erfolgt.";
    }
}
