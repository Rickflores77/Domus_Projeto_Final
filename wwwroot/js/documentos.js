// document.addEventListener("DOMContentLoaded", () => {

//     // ===== VOTAÇÕES =====
//     const votarBtns = document.querySelectorAll(".btn-votar");

//     votarBtns.forEach(btn => {
//         btn.addEventListener("click", () => {
//             const votacao = btn.closest(".votacao");

//             // Atualiza número de votos
//             const progressoText = votacao.querySelector(".progresso b");
//             const progressBar = votacao.querySelector(".progress-bar div");

//             let votos = progressoText.textContent.split(" de ");
//             let votosAtual = parseInt(votos[0]);
//             const votosTotal = parseInt(votos[1]);

//             votosAtual += 1; // incrementa o voto
//             progressoText.textContent = `${votosAtual} de ${votosTotal} votos`;

//             // Atualiza barra de progresso
//             const novaPercent = Math.min((votosAtual / votosTotal) * 100, 100);
//             progressBar.style.width = `${novaPercent}%`;

//             // Marca como votado visualmente
//             votacao.classList.remove("ativa");
//             votacao.classList.add("votado");

//             const titulo = votacao.querySelector(".titulo");
//             const status = document.createElement("span");
//             status.className = "status aprovado";
//             status.textContent = "Votado";
//             titulo.appendChild(status);

//             // Remove botão de votar
//             btn.remove();
//         });
//     });

//     // ===== DOWNLOAD DOCUMENTOS =====
//     const downloadBtns = document.querySelectorAll(".download");
//     downloadBtns.forEach(btn => {
//         btn.addEventListener("click", () => {
//             const docName = btn.closest(".documento").querySelector("p").textContent;
//             alert(`Iniciando download de "${docName}"...`);
//             // Aqui você poderia redirecionar para a URL real do arquivo
//         });
//     });

//     // ===== BARRA DE PROGRESSO ANIMADA =====
//     const progressBars = document.querySelectorAll(".progress-bar div");
//     progressBars.forEach(bar => {
//         const width = bar.style.width;
//         bar.style.width = "0%";
//         setTimeout(() => {
//             bar.style.transition = "width 1s ease";
//             bar.style.width = width;
//         }, 100);
//     });

// });
