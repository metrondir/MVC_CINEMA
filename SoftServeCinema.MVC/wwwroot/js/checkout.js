function checkout(pubkey, sessionId) {
    const stripe = Stripe(pubkey);
    stripe.redirectToCheckout({ sessionId });
}