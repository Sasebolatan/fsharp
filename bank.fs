// Define the Account type with name field
type Account = { AccountNumber: string; Name: string; Balance: float }

// Define the Ticket type with name field
type Ticket = { Seat: int; CustomerName: string }

// Method to print account details
let printAccountDetails (account: Account) =
    printfn "Account Number: %s, Name: %s, Balance: %.2f" account.AccountNumber account.Name account.Balance

// Method to print ticket details
let printTicketDetails (ticket: Ticket) =
    printfn "Seat: %d, Customer: %s" ticket.Seat ticket.CustomerName

// Method to check balance status
let checkBalanceStatus (balance: float) =
    if balance < 10.0 then
        printfn "Balance is too low to book a ticket"
    elif balance > 100.0 then
        printfn "Balance is too high"
    else
        printfn "Balance is within acceptable range"

// Create six accounts with names and balances
let accounts = [
    { AccountNumber = "0001"; Name = "GUY"; Balance = 5.0 }  // Low balance
    { AccountNumber = "0002"; Name = "DAY"; Balance = 51.0 } // Acceptable balance
    { AccountNumber = "0003"; Name = "ROSE"; Balance = 200.0 } // Sufficient balance
]

// Create a list of tickets with linked names
let mutable tickets = Array.create 10 { Seat = 0; CustomerName = "" }

// Method to book a seat for a customer
let bookSeat (customerName: string, seat: int, balance: float) =
    checkBalanceStatus balance
    if seat >= 1 && seat <= 10 && tickets.[seat - 1].CustomerName = "" then
        tickets.[seat - 1] <- { Seat = seat; CustomerName = customerName }
        printfn "Seat %d booked for %s" seat customerName
    else
        printfn "Cannot book seat due to low balance or seat already booked"

// Test booking seats with different account balances
bookSeat("GUY", 3, accounts.[0].Balance) // Low balance
bookSeat("DAY", 5, accounts.[1].Balance) // Acceptable balance
bookSeat("ROSE", 7, accounts.[2].Balance) // Sufficient balance
bookSeat("ROSE", 8, accounts.[2].Balance) // Sufficient balance

// Display account details and check balance status
printfn "Account details and balance status:"
accounts |> List.iter (fun acc ->
    printAccountDetails acc
    checkBalanceStatus acc.Balance
)

// Display ticket details
printfn "Ticket details:"
tickets |> Array.iter printTicketDetails
