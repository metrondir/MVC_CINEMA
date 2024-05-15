//document.getElementById('alert').addEventListener('click', e => {
//    e.target.remove();
//});
//window.addEventListener('load', function () {
//    document.body.classList.add('loaded');
//});
let ticket_array = [];
const ticket_container = document.querySelector('.ticket__container');
const ticketOrder = document.querySelector('.ticket__order');
ticketOrder.addEventListener('click', (e) => {
    e.preventDefault();
    if (e.target.dataset.id !== null) {
        if (ticket_array.filter(item => { return item.id == e.target.dataset.id; }).length !== 0
        ) {
            ticket_array = ticket_array.filter((item) => {
                return item.id !== e.target.dataset.id;
            });
            fromUnavailableToAvailable(ticket_container.querySelector('[data-id="'+e.target.dataset.id+'"]'));
            orderUpdate();
        }
    }
})

ticket_container.addEventListener('click', e => {
    e.preventDefault();
    if (e.target.dataset.id !== null) {
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
    
    ticketOrder.innerHTML = ' ';
    ticket_array.forEach((ticket) => {
        
        const p = document.createElement('p');
        p.innerText = ticket.row + '/' + ticket.seat + '  ' + ticket.price;
        p.dataset.id = ticket.id;
        ticketOrder.appendChild(p);
        
    })
   
    document.querySelector('#ticketsJSON').value = JSON.stringify(ticket_array.map((item) => {
        return item.id;
    }))
}
const fromAvailableToUnavailable = (button) => {
    button.classList.remove('ticket__seat-available');
    button.classList.add("ticket__seat-unavailable");
}
const fromUnavailableToAvailable = (button) => {
    button.classList.remove('ticket__seat-unavailable');
    button.classList.add("ticket__seat-available");
}

const ticket_buy = document.querySelector('#buyButton');
ticket_buy.addEventListener('click', () => {
    fetch("https://localhost:7262/Tag/Create", {
        method: 'post',
        body: JSON.stringify(ticket_array.map((item) => {
            return item.id;
        })),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).then((response) => {
        return response.json()
    }).then((res) => {
        if (res.status === 201) {
            console.log("Post successfully created!")
        }
    }).catch((error) => {
        ticketOrder.innerText = error;
    })
});