import React from 'react'

function HomeLayout({children}: {children: React.ReactNode}) {
  return (
    <>
      <header className="px-4 h-16 flex items-center pt-8">
        <nav className="flex justify-between items-center max-w-6xl mx-auto w-full">
          <div className="font-bold text-xl">2tinylink</div>

          <ul className="flex gap-3">
            <li>
              <button className="border-gray-900 border-2 px-4 py-2 text-gray-900 rounded-md active:scale-95">
                <a href="#">Login</a>
              </button>
            </li>
            <li>
              <button className="bg-gray-900 border-2 border-gray-900 px-4 py-2 text-white rounded-md active:scale-95">
                <a href="#">Register</a>
              </button>
            </li>
          </ul>
        </nav>
      </header>
      <main className="max-w-6xl mx-auto px-4 h-[calc(100vh_-_64px)] ">
        {children}
      </main>
    </>
  )
}

export default HomeLayout
