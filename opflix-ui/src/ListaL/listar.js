import React, {Component} from "react";
import './listar.css';
import Axios from 'axios';


export default class Lancamento extends Component {

    constructor (){
        super();
        this.state = {
            lista:[]
        }
    }

    direcionar = (event) => {
        this.props.history.push('/homeA')
    }

    componentDidMount = (event) => {
        // this.props.history.push('/lancamento')
        this.listarLancamento();
        console.log(this.state.lista)
    }

    listarLancamento = () =>{
        fetch('http://192.168.5.84:5000/api/Lancamento')
            .then(response => response.json())
            .then(data => this.setState({lista: data}))   
            // .then(data => this.console.log(data)) 
            .catch (erro=> console.log(erro))
    }

    render(){
        return(
<tr>

                <h1 className="lancamento">LANÇAMENTOS</h1>

        <div className="voltar">
        <button onClick = {this.direcionar}>Voltar</button>
        </div>
                
        <tbody className='lista'>
            {this.state.lista.map(element =>{
                return(

                    <tr key={element.idLancamento}>
                    <td >{element.nome}</td>
                </tr>
                    );
            })}
        </tbody>

</tr>

        );
    }
    
}
