FileInfo SourceFile = null;
StreamReader reader = null;

//List<string> linha;
string[] linha;
string[] linhasplit;
public struct op
{
	public string operacao;
	public int result;
	public void setValues(string o, int r)
	{
		operacao = o;
		result = r;
	}
	public string getOperacao(){
		return operacao;
	}
};

SourceFile = new FileInfo ("../CaixaOP/Assets/txt/op1.txt");

//Debug.Log ("todas as linhas:" + reader.ReadToEnd());
//Debug.Log ("Linha a linha" + reader.ReadLine().Split('|'));
int counter=0;
reader = SourceFile.OpenText ();
//Debug.Log ("Tamanho: " + reader.ReadToEnd().Split('|').Length);
//reader = SourceFile.OpenText ();
//Debug.Log ("Linha a linha" + reader.ReadLine().Split('|').ToString());
linha = reader.ReadLine().Split('|');
for(int x=0; x<linha.Length; x++)
	Debug.Log ("Linha a linha" + linha[x]);
//linha.AddRange(reader.ReadLine ().Split ('|'));
//counter++;
//for (int i = 0; i < linha.Length; i++) {
int idx=0;
Debug.Log (linha [idx].ToString ());
linhasplit = linha [idx].Split ("," [0]);
Debug.Log ("String: "+linhasplit [0].ToString ()+"Result: "+linhasplit[1].ToString());
//listaop[idx].setValues(linhasplit[0].ToString(), int.Parse(linhasplit[1].ToString()) );
//}