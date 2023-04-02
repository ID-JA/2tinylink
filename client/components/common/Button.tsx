import {ClassValue, clsx} from 'clsx'
import {VariantProps, cva} from 'cva'
import React from 'react'
import {twMerge} from 'tailwind-merge'

const buttonVariants = cva(
  'active:translate-y-[0.06rem] inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus:outline-none',

  {
    variants: {
      variant: {
        default: 'bg-black text-white hover:bg-black/95',
        destructive:
          'bg-red-500 text-white hover:bg-red-600 dark:hover:bg-red-600',
        outline:
          'bg-transparent border border-slate-200 hover:bg-slate-100 dark:border-slate-700',
        subtle:
          'bg-slate-100 text-slate-900 hover:bg-slate-200 dark:bg-slate-700',
        ghost:
          'bg-transparent hover:bg-slate-100 dark:hover:bg-slate-800 dark:hover:text-slate-100 data-[state=open]:bg-transparent dark:data-[state=open]:bg-transparent',
        link: 'bg-transparent dark:bg-transparent underline-offset-4 hover:underline text-slate-900 hover:bg-transparent dark:hover:bg-transparent',
      },
      size: {
        default: 'h-10 py-2 px-4',
        sm: 'h-9 px-2 rounded-md',
        lg: 'h-11 px-8 rounded-md',
      },
      cols: {
        default: 'col-span-1',
      },
    },
    defaultVariants: {
      variant: 'default',
      size: 'default',
    },
  },
)
export interface ButtonProps
  extends React.ButtonHTMLAttributes<HTMLButtonElement>,
    VariantProps<typeof buttonVariants> {}

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs))
}

const Button = React.forwardRef<HTMLButtonElement, ButtonProps>(
  ({className, variant, size, ...props}, ref) => {
    return (
      <button
        className={cn(buttonVariants({variant, size, className}))}
        ref={ref}
        {...props}
      />
    )
  },
)
Button.displayName = 'Button'

export {Button, buttonVariants}
