//document.getElementById('alert').addEventListener('click', e => {
//    e.target.remove();
//});
//window.addEventListener('load', function () {
//    document.body.classList.add('loaded');
//});

var swiper = new Swiper(".mySwiper", {
    slidesPerView: 5,
    spaceBetween: 30,
    loop: true,
    autoplay: true,
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});

let ticket_array = [];
const ticket_container = document.querySelector('.ticket__container');
const ticketOrder = document.querySelector('.tickets__container');
const ticketSum = document.querySelector('#ticketsSum');
const sumText = document.querySelector('#sum');
const ticketNum = document.querySelector('#ticketsNum');
let removeButton = '';
removeTicket = document.querySelector('#removeTicket');

ticketOrder.addEventListener('click', (e) => {
    e.preventDefault();
    if (e.target.dataset.id !== null && (e.target.matches('i') || e.target.matches('button'))) {
       
        if (ticket_array.filter(item => { return item.id == e.target.dataset.id; }).length !== 0) {
            ticket_array = ticket_array.filter((item) => {
                return item.id !== e.target.dataset.id;
            });
            fromUnavailableToAvailable(ticket_container.querySelector('[data-id="' + e.target.dataset.id + '"]'));
            orderUpdate();
        }
    }
})

ticket_container.addEventListener('click', e => {
    e.preventDefault();

    if (e.target.dataset.id != null && !e.target.classList.contains("ticket__seat-unavailable") && ticket_array.length < 8) {

        if (ticket_array.filter(item => {return item.id == e.target.dataset.id;}).length == 0
        ) {
            ticket_array.push({
                id: e.target.dataset.id,
                row: e.target.dataset.row,
                seat: e.target.dataset.seat,
                price: e.target.dataset.price,
});
            fromAvailableToUnavailable(e.target);
            orderUpdate();
        }
    }
})
const orderUpdate = () => {
    let sum = 0;
    ticketOrder.innerHTML = ' ';
    ticket_array.forEach((ticket) => {
        console.log(ticket.price);
        ticketOrder.appendChild(createTicketInfo(ticket.row, ticket.seat, parseFloat(ticket.price), parseFloat(ticket.price) == 350 ? "SUPER LUX" : "STANDART", ticket.id));
        sum += parseFloat(ticket.price);
    })
    ticketSum.innerHTML = sum + ' ГРН';
    sumText.innerHTML = ticketSum.innerHTML;
    console.log(sumText);
    ticketNum.innerHTML = ticket_array.length + (ticket_array.length > 1 ? ' tickets' : ' ticket') + ',';
    document.querySelector('#ticketsJSON').value = JSON.stringify(ticket_array.map((item) => {
        return item.id;
    }))
    if (ticket_array.length == 0) {
        const img = document.createElement('img');
        img.src = "/images/ticket1.png";
        img.alt = "defaultImg";
        ticketOrder.appendChild(img);
    }
        
   
}
const createTicketInfo = (row, seat, price, typeOfSeat, id) => {
    const form = document.createElement('form')
    const ticketInfo = document.createElement('div');
    ticketInfo.className = 'ticket__info';
    const ticketRowSeat = document.createElement('div');
    ticketRowSeat.className = 'ticket__row_seat';

    const rowSpan = document.createElement('span');
    rowSpan.textContent = `${row} row ${seat} seat `;
    ticketRowSeat.appendChild(rowSpan);

    const seatSpan = document.createElement('span');
    seatSpan.innerHTML = `<span>${typeOfSeat}</span>`;
    ticketRowSeat.appendChild(seatSpan);

    ticketInfo.appendChild(ticketRowSeat);

    const ticketPriceCancelButton = document.createElement('div');
    ticketPriceCancelButton.className = 'ticket__price_cancel-button';

    const priceSpan = document.createElement('span');
    priceSpan.textContent = `${price} грн`;
    ticketPriceCancelButton.appendChild(priceSpan);

    const cancelButton = document.createElement('button');
    const cancelIcon = document.createElement('i');
    cancelButton.dataset.id = id;
    cancelIcon.dataset.id = id;
    cancelIcon.className = 'fa-regular fa-circle-xmark';
    cancelButton.appendChild(cancelIcon);
    ticketPriceCancelButton.appendChild(cancelButton);

    ticketInfo.appendChild(ticketPriceCancelButton);

    return ticketInfo;
}
const fromAvailableToUnavailable = (button) => {
    button.classList.remove('ticket__seat-available');
    button.classList.add("ticket__seat-unavailable");
}
const fromUnavailableToAvailable = (button) => {
    button.classList.remove('ticket__seat-unavailable');
    button.classList.add("ticket__seat-available");

}