import { Component } from 'react';
import axios from 'axios';

import '../../assets/css/Login.css'
import logo from '../../assets/img/spmedicallogo.png'

export default class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            email: '',
            senha: '',
            mensagemErro: '',
            isLoading: false
        }
    };

    efetuarLogin = (evento) => {
        evento.preventDefault();

        this.setState({ mensagemErro: '', isLoading: true })
        axios.post('http://localhost:5000/api/Login', {
            email: this.state.email,
            senha: this.state.senha
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    localStorage.setItem('usuario-login', resposta.data.token);
                    this.setState({ isLoading: false });
                    console.log(localStorage.getItem('usuario-login'))
                }
            })

            .catch(() => {
                this.setState({
                    mensagemErro: 'Email ou senha invalida', isLoading: false,
                    email: '',
                    senha: ''
                })
            })
    }

    atualizarStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    };

    render() {
        return (
            <div>
                <div className="container-left">
                    <a href="Main.html" className="Logo_login">
                        <img src= {logo} className="logo_img" /> </a>
                </div>

                <div className="QuadradoUm">
                    <div className="container-right">
                        <h1>Login</h1>
                        <form className="input-login" onSubmit={this.efetuarLogin}>

                            <div className="input-box">
                                <input type="email" name="email" className="input-content" id="e-mail" placeholder="E-Mail" value={this.state.email} onChange={this.atualizarStateCampo} />
                                <input type="password" name="senha" className="input-content" id="senha" placeholder="Senha" value={this.state.senha} onChange={this.atualizarStateCampo} />
                            </div>
                            <button type="submit" className="btn-login">Logar</button>
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}