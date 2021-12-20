import { useState, useEffect } from 'react'
import axios from 'axios'

export default function ConsultaMedico() {
    const [listaminhasconsultas, setListasminhasconsultas] = useState([]);
    function BuscarMeusEventos() {
        axios('http://localhost:5000/api/Consulta/Medico', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then((resposta) => {
            console.log("skiii")
            if (resposta.status === 200) {
                console.log(resposta.data)
                // setListasminhasconsultas(resposta.data)
            }
        }).catch(erro => console.log(erro))
    }

    useEffect(BuscarMeusEventos, [])

    return (
        <div>
            <span>{listaminhasconsultas.dataConsulta}</span>
        </div>
    )
}