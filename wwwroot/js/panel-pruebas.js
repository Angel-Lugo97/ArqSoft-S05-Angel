async function pedirDatos(url, salidaId, statusId) {
    const salida = document.getElementById(salidaId);
    const status = document.getElementById(statusId);

    salida.textContent = "Cargando...";
    status.textContent = "-";
    status.className = "status";

    try {
        const respuesta = await fetch(url);
        const texto = await respuesta.text();

        let datos;

        try {
            datos = JSON.parse(texto);
        } catch {
            datos = texto;
        }

        status.textContent = respuesta.status;

        if (respuesta.ok) {
            status.className = "status ok";
        } else {
            status.className = "status error";
        }

        salida.textContent = typeof datos === "string"
            ? datos
            : JSON.stringify(datos, null, 2);

    } catch (error) {
        status.textContent = "Error";
        status.className = "status error";
        salida.textContent = error.message;
    }
}

function listarPacientes() {
    pedirDatos("/api/pacientes", "salidaPacientes", "statusPacientes");
}

function buscarPaciente() {
    const id = document.getElementById("pacienteId").value;
    pedirDatos(`/api/pacientes/${id}`, "salidaPacientes", "statusPacientes");
}

function listarMedicos() {
    pedirDatos("/api/medicos", "salidaMedicos", "statusMedicos");
}

function buscarMedico() {
    const id = document.getElementById("medicoId").value;
    pedirDatos(`/api/medicos/${id}`, "salidaMedicos", "statusMedicos");
}

function listarCitas() {
    pedirDatos("/api/citas", "salidaCitas", "statusCitas");
}

function buscarCitasPorPaciente() {
    const id = document.getElementById("pacienteCitaId").value;
    pedirDatos(`/api/citas/por-paciente/${id}`, "salidaCitas", "statusCitas");
}

function calcular(operacion) {
    const a = document.getElementById("numeroA").value;
    const b = document.getElementById("numeroB").value;

    pedirDatos(
        `/api/calculadora/${operacion}?a=${a}&b=${b}`,
        "salidaCalculadora",
        "statusCalculadora"
    );
}

document.addEventListener("DOMContentLoaded", function () {
    listarPacientes();
    buscarMedico();
    buscarCitasPorPaciente();
});
