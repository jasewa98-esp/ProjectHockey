using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;

public class ConexionBBDD : MonoBehaviour
{
    public Text name;
    public Text email;
    public Text pass;
    private string connectionString;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    string query;

    public void sendInfo() {

        connection();

        query = "INSERT INTO usuari (nom_usuari, email, password) VALUES( " + name.text + " , " + email.text + "," + pass.text + ");";

        MS_Command = new MySqlCommand(query, MS_Connection);

        MS_Command.ExecuteNonQuery();

        MS_Connection.Close();
    }

    public void connection() {

        connectionString = "Server = localhost ; Database = projecte_final_ok ; User = root; Password = ; Charset = utf8;";
        MS_Connection = new MySqlConnection(connectionString);

        MS_Connection.Open();

    }

}

