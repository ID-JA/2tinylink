import {Button} from '@/components/common'
import React from 'react'

function HomeLayout({children}: {children: React.ReactNode}) {
  return (
    <>
      <header className="flex items-center h-16 px-4 ">
        <nav className="flex items-center justify-between w-full max-w-6xl mx-auto">
          <div className="text-xl font-bold">2tinylink</div>

          <ul className="flex gap-3">
            <li>
              <Button>Login</Button>
            </li>
            <li>
              <Button variant="outline">Register</Button>
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
