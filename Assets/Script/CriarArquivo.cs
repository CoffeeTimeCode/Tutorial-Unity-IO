using UnityEngine;
using UnityEngine.UI; //Para manipular as UIs
using System.IO; //Para manipular Entrada e saida de Dados
using System.Collections;

public class CriarArquivo : MonoBehaviour {

	public Config _config;
	public InputField _texto;
	public InputField _nomeArquivo;

	// Use this for initialization
	void Start () {
		_config = GameObject.Find("Canvas").GetComponent<Config>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void NovoArquivo()
	{
		if (_nomeArquivo.text == "") {
			_config._msg.text = "Erro: Arquivo ja Existe ou Nome Do Arquivo Em Branco";
		} else {
			var _arquivo = File.CreateText(_config._local + "/" + _nomeArquivo.text + ".txt");
			_arquivo.WriteLine(_texto.text);
			_arquivo.Close();
			_texto.text = "";
			_config._msg.text = "Arquivo Criado Com Sucesso.";
		}
	}
	public void AbrirArquivo()
	{
		if (_nomeArquivo.text != "") 
		{
			if(File.Exists(_config._local+"/"+_nomeArquivo.text+".txt"))
			{
				var _arquivo = File.OpenText(_config._local+"/"+_nomeArquivo.text+".txt");
				_texto.text = _arquivo.ReadLine();
				_arquivo.Close();
				_config._msg.text = "Arquivo Carregado Com Sucesso.";
			}
			else
			{
				_config._msg.text = "Erro: Arquivo Nao Existe.";
			}
		}
		else
		{
			_config._msg.text = "Erro: Nome Do Arquivo Em Branco.";
		}
	}
	public void DeletarArquivo()
	{
		if(_nomeArquivo.text!="")
		{
			if(File.Exists(_config._local+"/"+_nomeArquivo.text+".txt"))
			{
				File.Delete(_config._local+"/"+_nomeArquivo.text+".txt");
				_config._msg.text = "Arquivo Deletado Com Sucesso.";
			}
			else
			{
				_config._msg.text = "Erro: Arquivo Nao Existe.";
			}
		}
		else
		{
			_config._msg.text = "Erro: Nome Do Arquivo Em Branco.";
		}
	}
}
