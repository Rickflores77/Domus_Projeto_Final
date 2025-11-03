// document.addEventListener("DOMContentLoaded", () => {

//     // ===== CONTAS =====
//     const bills = document.querySelectorAll(".bill");
//     const totalSpan = document.querySelector(".total strong");

//     function updateTotal() {
//         let total = 0;
//         bills.forEach(bill => {
//             const status = bill.querySelector(".status").textContent.toLowerCase();
//             if (status === "pendente") {
//                 const valueText = bill.querySelector("small").textContent.replace("R$", "").replace(",", ".").trim();
//                 total += parseFloat(valueText);
//             }
//         });
//         totalSpan.textContent = "R$ " + total.toFixed(2).replace(".", ",");
//     }

//     bills.forEach(bill => {
//         bill.addEventListener("click", () => {
//             const status = bill.querySelector(".status");
//             if (status.textContent === "Pago") {
//                 status.textContent = "Pendente";
//                 status.classList.remove("pago");
//                 status.classList.add("pendente");
//             } else {
//                 status.textContent = "Pago";
//                 status.classList.remove("pendente");
//                 status.classList.add("pago");
//             }
//             updateTotal();
//         });
//     });

//     updateTotal(); // inicializa o total

//     // ===== RESERVAS =====
//     const reservaItems = document.querySelectorAll(".card .item");
//     const today = new Date();

//     reservaItems.forEach(item => {
//         const small = item.querySelector("small");
//         if (small) {
//             const dateText = small.textContent.split(" às ")[0]; // ex: 15/10/2025
//             const [day, month, year] = dateText.split("/");
//             const date = new Date(year, month - 1, day);
//             if (date < today) {
//                 item.style.display = "none"; // oculta reservas passadas
//             }
//         }
//     });

//     // ===== MENSAGENS =====
//     const messages = document.querySelectorAll(".card .item");

//     messages.forEach(msg => {
//         msg.addEventListener("click", () => {
//             const badge = msg.querySelector(".badge");
//             if (badge) {
//                 badge.remove(); // remove badge "Novo" ao abrir
//             }
//         });
//     });

// });
